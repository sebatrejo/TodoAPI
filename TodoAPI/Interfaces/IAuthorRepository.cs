using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Interfaces
{
    public interface IAuthorRepository
    {
        List<Author> List();
        Author GetByAlias(string twitterAlias);
        List<Author> GetByNameSubstring(string nameSubstring);
    }
}
