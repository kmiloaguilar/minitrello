using System.Collections.Generic;

namespace MiniTrello.Domain.DataObjects
{
    public class OrganizationModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AccountBoardModel> Boards { get; set; }
    }
}