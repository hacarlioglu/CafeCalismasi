using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amsterdam.Models
{
    internal interface Interface
    {
        
            Task<string> UploadImage(IFormFile file);
    
    }
}
