﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management.Model.Interface
{
	interface ILoginModel
	{
		void AuthenticateLogin(Employee employee);
		void Logout();
	}
}
