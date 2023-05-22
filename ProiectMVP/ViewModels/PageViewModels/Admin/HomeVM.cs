using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMVP.Models;

namespace ProiectMVP.ViewModels.PageViewModels.Admin
{ 
	class HomeVM : BaseViewModel
	{
		public readonly PageModel _pageModel;

		public HomeVM()
		{
			_pageModel = new PageModel();
		}
	}
}
