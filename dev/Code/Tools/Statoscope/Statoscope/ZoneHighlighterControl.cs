/*
* All or portions of this file Copyright (c) Amazon.com, Inc. or its affiliates or
* its licensors.
*
* For complete copyright and license terms please see the LICENSE at the root of this
* distribution (the "License"). All use of this software is governed by the License,
* or, if provided, by the license below or the license accompanying this file. Do not
* remove or modify any license notices. This file is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*
*/
// Original file Copyright Crytek GMBH or its affiliates, used under license.

using System.Windows.Forms;

namespace Statoscope
{
	class ZoneHighlighterControl<T> : RDIInfoControl<ZoneHighlighterRDI> where T : ZoneHighlighterRDI
	{
		protected bool ZHIResetEnabled = true;

		protected override ZoneHighlighterRDI RDI
		{
			set
			{
				base.RDI = value;
				ZRDI = value as T;
			}
		}

		protected virtual T ZRDI
		{
			get { return RDI as T; }
			set { }
		}

		protected ZoneHighlighterControl(LogControl logControl, ZoneHighlighterRDI zrdiTree, RDICheckboxTreeView<ZoneHighlighterRDI> zrdiCTV)
			: base(logControl, zrdiTree, zrdiCTV)
		{
		}

		protected void ResetZHIs()
		{
			if (!ZHIResetEnabled)
				return;

			LogControl.ResetZoneHighlighter(ZRDI);
		}
	}
}