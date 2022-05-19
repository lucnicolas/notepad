using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notepad.Models;

namespace Notepad.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteModel>> Read();
        Task<NoteModel> Read(int id);
        Task<NoteModel> Create(NoteModel model);
        Task<NoteModel> Update(int id, NoteModel model);
        Task<NoteModel> Delete(int id);
    }
}