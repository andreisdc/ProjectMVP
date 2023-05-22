using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMVP.Models;


namespace ProiectMVP.ViewModels.PageViewModels.Admin
{
	class ClassVM : BaseViewModel
	{
		private readonly PageModel _pageModel;

		public ClassVM()
		{
			_pageModel = new PageModel();
		}
	}
}
