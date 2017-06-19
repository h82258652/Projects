using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SoftwareKobo.Extensions
{
    public static class VisualTreeHelperExtensions
    {
        public static IEnumerable<DependencyObject> GetAncestors(this DependencyObject start, bool includeStart = false)
        {
            if (start == null)
            {
                yield break;
            }

            if (includeStart)
            {
                yield return start;
            }

            var parent = VisualTreeHelper.GetParent(start);

            while (parent != null)
            {
                yield return parent;
                parent = VisualTreeHelper.GetParent(parent);
            }
        }

        public static IEnumerable<T> GetAncestorsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestors().OfType<T>();
        }

        public static Rect GetBoundingRect(this UIElement dob, UIElement relativeTo = null)
        {
            if ((bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)
            {
                return Rect.Empty;
            }

            if (relativeTo == null)
            {
                relativeTo = Application.Current.MainWindow.Content as FrameworkElement;
            }

            if (relativeTo == null)
            {
                throw new InvalidOperationException("Element not in visual tree.");
            }

            if (dob == relativeTo)
            {
                var fe = relativeTo as FrameworkElement;
                var aw = fe?.ActualWidth ?? 0;
                var ah = fe?.ActualHeight ?? 0;

                return new Rect(0, 0, aw, ah);
            }

            //var ancestors = dob.GetAncestors().ToArray();

            //if (!ancestors.Contains(relativeTo))
            //{
            //    throw new InvalidOperationException("Element not in visual tree.");
            //}

            var fe2 = dob as FrameworkElement;
            var aw2 = fe2?.ActualWidth ?? 0;
            var ah2 = fe2?.ActualHeight ?? 0;

            var topLeft =
                dob
                    .TransformToVisual(relativeTo)
                    .Transform(new Point());
            var topRight =
                dob
                    .TransformToVisual(relativeTo)
                    .Transform(
                        new Point(
                            aw2,
                            0));
            var bottomLeft =
                dob
                    .TransformToVisual(relativeTo)
                    .Transform(
                        new Point(
                            0,
                            ah2));
            var bottomRight =
                dob
                    .TransformToVisual(relativeTo)
                    .Transform(
                        new Point(
                            aw2,
                            ah2));

            var minX = new[] { topLeft.X, topRight.X, bottomLeft.X, bottomRight.X }.Min();
            var maxX = new[] { topLeft.X, topRight.X, bottomLeft.X, bottomRight.X }.Max();
            var minY = new[] { topLeft.Y, topRight.Y, bottomLeft.Y, bottomRight.Y }.Min();
            var maxY = new[] { topLeft.Y, topRight.Y, bottomLeft.Y, bottomRight.Y }.Max();

            return new Rect(minX, minY, maxX - minX, maxY - minY);
        }

        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject parent)
        {
            if (parent == null)
            {
                yield break;
            }

            var popup = parent as Popup;

            if (popup?.Child != null)
            {
                yield return popup.Child;
                yield break;
            }

            var count = VisualTreeHelper.GetChildrenCount(parent);

            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                yield return child;
            }
        }

        public static IEnumerable<DependencyObject> GetChildrenByZIndex(
           this DependencyObject parent)
        {
            var i = 0;
            var indexedChildren =
                parent.GetChildren().Cast<FrameworkElement>().Select(
                child => new { Index = i++, ZIndex = Panel.GetZIndex(child), Child = child });

            return
                from indexedChild in indexedChildren
                orderby indexedChild.ZIndex, indexedChild.Index
                select indexedChild.Child;
        }

        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject start, bool includeStart = false)
        {
            if (start == null)
            {
                yield break;
            }

            if (includeStart)
            {
                yield return start;
            }

            var queue = new Queue<DependencyObject>();

            var popup = start as Popup;

            if (popup != null)
            {
                if (popup.Child != null)
                {
                    queue.Enqueue(popup.Child);
                    yield return popup.Child;
                }
            }
            else
            {
                int childrenCount;

                try
                {
                    if (start is UIElement)
                    {
                        childrenCount = VisualTreeHelper.GetChildrenCount(start);
                    }
                    else
                    {
                        childrenCount = 0;
                    }
                }
                catch (Exception)
                {
                    childrenCount = 0;
                }

                for (var i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(start, i);
                    queue.Enqueue(child);
                    yield return child;
                }
            }

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                popup = parent as Popup;

                if (popup != null)
                {
                    if (popup.Child != null)
                    {
                        queue.Enqueue(popup.Child);
                        yield return popup.Child;
                    }
                }
                else
                {
                    int childrenCount;

                    try
                    {
                        childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                    }
                    catch (Exception)
                    {
                        childrenCount = 0;
                    }

                    for (var i = 0; i < childrenCount; i++)
                    {
                        var child = VisualTreeHelper.GetChild(parent, i);
                        yield return child;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public static IEnumerable<T> GetDescendantsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendants().OfType<T>();
        }

        public static T GetFirstAncestorOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestorsOfType<T>().FirstOrDefault();
        }

        public static T GetFirstDescendantOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendantsOfType<T>().FirstOrDefault();
        }

        public static Point GetPosition(this UIElement dob, Point origin = new Point(), UIElement relativeTo = null)
        {
            if ((bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)
            {
                return new Point();
            }

            if (relativeTo == null)
            {
                relativeTo = Application.Current.MainWindow.Content as UIElement;
            }

            if (relativeTo == null)
            {
                throw new InvalidOperationException("Element not in visual tree.");
            }

            var fe = relativeTo as FrameworkElement;
            var aw = fe?.ActualWidth ?? 0;
            var ah = fe?.ActualHeight ?? 0;

            var absoluteOrigin = new Point(aw * origin.X, ah * origin.X);

            if (dob == relativeTo)
            {
                return absoluteOrigin;
            }

            var ancestors = dob.GetAncestors().ToArray();

            if (!ancestors.Contains(relativeTo))
            {
                throw new InvalidOperationException("Element not in visual tree.");
            }

            return
                dob
                    .TransformToVisual(relativeTo)
                    .Transform(absoluteOrigin);
        }

        public static UIElement GetRealWindowRoot(Window window = null)
        {
            if (window == null)
            {
                window = Application.Current.MainWindow;
            }

            if (window == null)
            {
                return null;
            }

            var root = window.Content as FrameworkElement;

            var ancestors = root?.GetAncestors().ToList();

            if (ancestors?.Count > 0)
            {
                root = (FrameworkElement)ancestors[ancestors.Count - 1];
            }

            return root;
        }

        public static IEnumerable<DependencyObject> GetSiblings(this DependencyObject start)
        {
            if (start == null)
            {
                yield break;
            }

            var parent = VisualTreeHelper.GetParent(start);

            if (parent == null)
            {
                yield return start;
            }
            else
            {
                var count = VisualTreeHelper.GetChildrenCount(parent);

                for (var i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    yield return child;
                }
            }
        }

        public static bool IsInVisualTree(this DependencyObject dob)
        {
            if ((bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)
            {
                return false;
            }

            if (Application.Current.MainWindow == null)
            {
                // This may happen when a picker or CameraCaptureUI etc. is open.
                return false;
            }

            var root = GetRealWindowRoot();

            return
                root != null && dob.GetAncestors(includeStart: true).Contains(root);
        }
    }
}