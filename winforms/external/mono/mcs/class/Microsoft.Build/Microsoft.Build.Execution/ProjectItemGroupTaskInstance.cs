//
// ProjectItemGroupTaskInstance.cs
//
// Author:
//    Atsushi Enomoto (atsushi@xamarin.com)
//
// (C) 2013 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Construction;

namespace Microsoft.Build.Execution
{
	public sealed class ProjectItemGroupTaskInstance : ProjectTargetInstanceChild
	{
		internal ProjectItemGroupTaskInstance (ProjectItemGroupElement xml)
		{
			condition = xml.Condition;
			condition_location = xml.ConditionLocation;
			//this.FullPath = fullPath;
			location = xml.Location;
			
			Items = xml.Items.Select (item => new ProjectItemGroupTaskItemInstance (item)).ToArray ();
		}
		
		readonly string condition;
		readonly ElementLocation condition_location, location;
		
		public override string Condition {
			get { return condition; }
		}

		#if NET_4_5
		public
		#else
		internal
		#endif
		override ElementLocation ConditionLocation {
			get { return condition_location; }
		}

		#if NET_4_5
		public
		#else
		internal
		#endif
		override ElementLocation Location {
			get { return location; }
		}

		#if NET_4_5
		public
		#else
		internal
		#endif
		ElementLocation ExecuteTargetsLocation { get; private set; }
		
		public ICollection<ProjectItemGroupTaskItemInstance> Items { get; private set; }
	}
}

