﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.IToken
{
	public interface ITokenHandler
	{
		string GenereteJwtToken(string email, string role);
	}
}
