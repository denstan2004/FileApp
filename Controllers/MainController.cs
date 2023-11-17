using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using TestAppFile.DAO.Repos;
using TestAppFile.Enteties;
using TestAppFile.Services;

namespace TestAppFile.Controllers
{
    [Route("Home")]
    public class MainController : Controller
    {
        private readonly FileRepository _fileRepository;
        private readonly UserFileParser _userFileParser;
        private readonly DirCreate _dirCreate;

        public MainController(FileRepository fileRepository, UserFileParser userFileParser, DirCreate dirCreate)
        {
            _dirCreate = dirCreate;
            _fileRepository = fileRepository;
            _userFileParser = userFileParser;
        }

        [HttpGet("main")]
        public List<FileEntity> MainPage()
        {
            FileEntity file = _fileRepository.getSourceElement();
            List<FileEntity> childFiles = _fileRepository.GetChildFiles(file.ID);

            List<FileEntity> allFiles = new List<FileEntity>();
            allFiles.Add(file);
            allFiles.AddRange(childFiles);

            return allFiles;
        }

        [HttpGet("file/{id}")]
        public List<FileEntity> File(int id)
        {
            FileEntity file = _fileRepository.GetById(id);
            List<FileEntity> childFiles = _fileRepository.GetChildFiles(id);

            List<FileEntity> allFiles = new List<FileEntity>();
            allFiles.Add(file);
            allFiles.AddRange(childFiles);


            return allFiles;
        }

        [HttpGet("user/file")]
        public IActionResult UserFiles()
        {
            String source = "test";
            _userFileParser.parseAllFiles(source);
            return Ok();
            
        }
        [HttpGet("crete")]
        public IActionResult CreateFilles()
        {
            string dir = "C:\\Users\\Admin\\projects\\TestAppFile\\test2";
            _dirCreate.createDirs(dir, 3);
            return Ok();
        }
    }
}
/* прохід від сурса по гілкам, задається нехай в функцію сурс і шлях, для початку шлях буде 
 * типу C:\\Users\\Admin\\projects\\TestAppFile після чого ми знаходимо сурс в бд додаємо,
 * і проходимо по в низ, додаючи нові сурси і шлях просто дописуємо відповідно сурс до шляху і додаємо
 */