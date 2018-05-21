using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
