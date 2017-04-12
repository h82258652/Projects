#pragma once
#include "SystemMetric.h"

namespace SoftwareKobo
{
	namespace PInvoke
	{
		public ref class User32 sealed
		{
		private:
			User32()
			{
			}

		public:
			static int GetSystemMetrics(SystemMetric smIndex);
		};
	}
}