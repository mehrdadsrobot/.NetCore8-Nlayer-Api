using Models.UserModels;

namespace Models
{
    public class Videos
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; } // the user Id....
        public DateTime? Created { get; set; }
        public ICollection <Category> Categories{ get; set; }

        public Users User;

    }
}
