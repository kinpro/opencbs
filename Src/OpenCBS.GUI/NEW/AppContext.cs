﻿// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// 
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System.Windows.Forms;
using OpenCBS.GUI.NEW.Presenter;
using OpenCBS.GUI.NEW.View;
using StructureMap;

namespace OpenCBS.GUI.NEW
{
    public class AppContext : ApplicationContext
    {
        private readonly IContainer _container;

        public AppContext(IContainer container)
        {
            _container = container;
            MainForm = GetMainForm();
        }

        private Form GetMainForm()
        {
            var mainForm = new LotrasmicMainWindowForm();
            _container.Inject<IMainView>(mainForm);

            var presenter = _container.GetInstance<MainPresenter>();
            presenter.Run();

            return (Form)presenter.View;
        }
    }
}
