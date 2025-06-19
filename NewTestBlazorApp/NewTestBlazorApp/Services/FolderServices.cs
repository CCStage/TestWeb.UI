using NewTestBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewTestBlazorApp.Services
{
    public class FolderService
    {
        private int nextId = 1;
        private readonly List<BusinessDossierFolder> folders = new();
        private readonly HashSet<int?> expandedFolders = new();
        private readonly Dictionary<int?, string> subfolderNames = new();
        private int? folderIdAwaitingSubfolder;

        public List<BusinessDossierFolder> Folders => folders;
        public HashSet<int?> ExpandedFolders => expandedFolders;
        public Dictionary<int?, string> SubfolderNames => subfolderNames;
        public int? FolderIdAwaitingSubfolder => folderIdAwaitingSubfolder;

        private const int MaxFolderDepth = 4;

        public void ToggleFolder(int? folderId)
        {
            if (expandedFolders.Contains(folderId))
                expandedFolders.Remove(folderId);
            else
                expandedFolders.Add(folderId);
        }
    }
}
