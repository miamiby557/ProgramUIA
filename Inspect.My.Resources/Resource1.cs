using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Inspect.My.Resources
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resource1
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = object.ReferenceEquals(Resource1.resourceMan, null);
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Inspect.Resource1", typeof(Resource1).Assembly);
					Resource1.resourceMan = resourceManager;
				}
				return Resource1.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resource1.resourceCulture;
			}
			set
			{
				Resource1.resourceCulture = value;
			}
		}

		internal Resource1()
		{
		}
	}
}
