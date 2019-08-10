﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;

namespace Dock.Model
{
    public abstract class DockBase : ViewBase, IDock
    {
        private INavigateAdapter _navigateAdapter;

        public IList<IView> Views { get; set; }

        public IView CurrentView { get; set; }

        public IView DefaultView { get; set; }

        public IView FocusedView { get; set; }

        public double Proportion { get; set; } = double.NaN;

        public bool IsActive { get; set; }

        public bool IsCollapsable { get; set; } = true;

        public bool CanGoBack => _navigateAdapter?.CanGoBack ?? false;

        public bool CanGoForward => _navigateAdapter?.CanGoForward ?? false;

        public IList<IDockWindow> Windows { get; set; }

        public IDockFactory Factory { get; set; }

        public DockBase()
        {
            _navigateAdapter = new NavigateAdapter(this);
        }

        public virtual void GoBack()
        {
            _navigateAdapter?.GoBack();
        }

        public virtual void GoForward()
        {
            _navigateAdapter?.GoForward();
        }

        public virtual void Navigate(object root)
        {
            _navigateAdapter?.Navigate(root, true);
        }

        public virtual void ShowWindows()
        {
            _navigateAdapter?.ShowWindows();
        }

        public virtual void ExitWindows()
        {
            _navigateAdapter?.ExitWindows();
        }

        public virtual void Close()
        {
            _navigateAdapter?.Close();
        }
    }
}
