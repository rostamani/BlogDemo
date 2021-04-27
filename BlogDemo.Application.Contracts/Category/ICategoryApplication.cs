using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Application.Contracts.Category
{
    public interface ICategoryApplication
    {
        List<CategoryViewModel> Search(string name);

        EditCategory GetDetails(int id);

        void Create(CreateCategory command);

        void Edit(EditCategory command);
    }
}
