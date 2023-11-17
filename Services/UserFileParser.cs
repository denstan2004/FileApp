using TestAppFile.DAO.Repos;
using TestAppFile.Enteties;

namespace TestAppFile.Services
{
    public class UserFileParser
    {
        private readonly FileRepository _fileRepository;
   

        public UserFileParser(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;

        }
        const String source = "test";


        public void parseAllFiles(string source)
        {
            if (_fileRepository.FindByName(source.Split("\\").Last())==null)
            {
                    _fileRepository.AddFolder(source);          
            }
            IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories(source);
            if(listOfDirectories.Any())
            {
                foreach (var subfolder in listOfDirectories)
                {
                    var sb = subfolder.Split("\\").Last();
                    _fileRepository.AddFolder(sb);
                    FileEntity parent = _fileRepository.FindByName(source.Split("\\").Last());
                    FileEntity child = _fileRepository.FindByName(sb);
                    _fileRepository.AddLinks(parent.ID, child.ID);
                    parseAllFiles(subfolder);
                }
            }

           
        }
    }
}
//"test\\Folder1",
  //  "test\\Folder2",
    //"test\\Folder3"