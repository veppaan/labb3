
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace guestbook
{
    public class Guestbook
    {
        private string filename = @"guestbook.json";
        private List<Post> posts = new List<Post>();

        public Guestbook()
        {
            //Läs allt i filename
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }
        public Post addPost(string g, string t)
        {
            Post obj = new Post();
            obj.Guest = g;
            obj.Message = t;
            save();
            return obj;
        }
        public int deletePost(int index)
        {
            posts.RemoveAt(index);
            save();
            return index;
        }
        public List<Post> getPosts()
        {
            return posts;
        }


    //Spara alla objekt till json i filen
        private void save()
        {
            string jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }

    }
}