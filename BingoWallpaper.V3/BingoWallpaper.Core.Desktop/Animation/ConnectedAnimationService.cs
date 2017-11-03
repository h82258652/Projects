using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BingoWallpaper.Animation
{
    public sealed class ConnectedAnimationService
    {
        private static readonly TimeSpan AnimationAvailableTime = TimeSpan.FromSeconds(2);

        private static readonly Dictionary<Window, ConnectedAnimationService> ConnectedAnimationServiceInstances = new Dictionary<Window, ConnectedAnimationService>();

        private readonly Dictionary<string, ConnectedAnimation> _animations = new Dictionary<string, ConnectedAnimation>();

        private ConnectedAnimationService()
        {
        }

        public TimeSpan DefaultDuration
        {
            get;
            set;
        } = TimeSpan.FromSeconds(0.3);

        public IEasingFunction DefaultEasingFunction
        {
            get;
            set;
        } = new CubicBezierEase()
        {
            ControlPoint1 = new Point(0.3, 0.3),
            ControlPoint2 = new Point(0, 1)
        };

        public static ConnectedAnimationService GetForCurrentView()
        {
            var currentWindow = Application.Current.Windows.Cast<Window>().SingleOrDefault(temp => temp.IsActive);
            if (currentWindow == null)
            {
                return null;
            }

            var connectedAnimationServiceInstances = ConnectedAnimationServiceInstances;
            lock (connectedAnimationServiceInstances)
            {
                if (connectedAnimationServiceInstances.ContainsKey(currentWindow))
                {
                    return connectedAnimationServiceInstances[currentWindow];
                }
                else
                {
                    var connectedAnimationService = new ConnectedAnimationService();
                    connectedAnimationServiceInstances.Add(currentWindow, connectedAnimationService);
                    return connectedAnimationService;
                }
            }
        }

        public ConnectedAnimation GetAnimation(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            _animations.TryGetValue(key, out var animation);
            return animation;
        }

        public ConnectedAnimation PrepareToAnimate(string key, UIElement source)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var animation = new ConnectedAnimation(this, source);
            void AnimationCompleted(ConnectedAnimation sender, object args)
            {
                animation.Completed -= AnimationCompleted;
                RemoveAnimation(key, animation);
            }
            animation.Completed += AnimationCompleted;
            _animations[key] = animation;

            async void AsyncAction()
            {
                await Task.Delay(AnimationAvailableTime);
                RemoveAnimation(key, animation);
            }
            AsyncAction();

            return animation;
        }

        private void RemoveAnimation(string key, ConnectedAnimation animation)
        {
            if (_animations.TryGetValue(key, out var temp)
                && temp == animation)
            {
                animation.IsAvailable = false;
                _animations.Remove(key);
            }
        }
    }
}