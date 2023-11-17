using Microsoft.AspNetCore.SignalR;
using TestAppFile.Enteties;

namespace TestAppFile.DAO.Repos
{
    public class FileRepository
    {
        private readonly ApplicationDbContext _context;
        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FileEntity> GetAll()
        {
            List<FileEntity> files = new List<FileEntity>();
            files = _context.files.ToList();
            return files;
        }

        public FileEntity GetById(int id)
        {
            return _context.files.SingleOrDefault(x => x.ID == id);
        }

        public List<FileEntity> GetChildFiles(int id)
        {
            List<FileEntity> childFiles = new List<FileEntity>();
            List<FileLinks> fileLinks = new List<FileLinks>();
            fileLinks = _context.links.Where(x => x.ParentId == id).ToList();

            for (int i = 0; i < fileLinks.Count; i++)
            {
                var link = fileLinks[i];
                childFiles.Add(GetById(link.childId));
            }
            return childFiles;
        }

        public FileEntity getSourceElement()
        {
            FileEntity file = new FileEntity();

            List<FileEntity> files = new List<FileEntity>();
            files = _context.files.ToList();
            List<FileLinks> filesLinks = new List<FileLinks>();
            filesLinks = _context.links.ToList();
            foreach (FileEntity f in files)
            {
                Boolean isThere = false;
                foreach (FileLinks l in filesLinks)
                {
                    if (f.ID == l.childId)
                    {
                        isThere = true;
                        break;
                    }
                }
                if (!isThere)
                {
                    file = f;
                    break;
                }
            }

            return file;
        }


        public void AddFolder(string name)
        {
            var newEntity = new FileEntity { Name = name };
            _context.files.Add(newEntity);
            _context.SaveChanges();
        }

        public FileEntity FindByName(string name)
        {
            FileEntity file = _context.files.SingleOrDefault(f => f.Name == name);
            return file;
        }
        
        public void AddLinks(int parentId, int childId)
        {
            FileLinks links = new FileLinks();
            links.ParentId = parentId;
            links.childId = childId;
            _context.links.Add(links);
            _context.SaveChanges();
        }

    }
}
