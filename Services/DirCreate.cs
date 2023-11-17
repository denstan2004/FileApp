using System.Reflection.Metadata;
using TestAppFile.DAO.Repos;
using TestAppFile.Enteties;

namespace TestAppFile.Services
{
    public class DirCreate
    {
        private readonly FileRepository _fileRepository;


        public DirCreate(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;

        }
        public void createDirs(string path, int id)
        {
           FileEntity file= _fileRepository.GetById(id);
            String newPath = path + "\\" + file.Name;
            Directory.CreateDirectory(newPath);
            List<FileEntity> childs = _fileRepository.GetChildFiles(id);
            foreach (FileEntity child in childs)
            {
                createDirs(newPath,child.ID);
            }

        }
    }
}
