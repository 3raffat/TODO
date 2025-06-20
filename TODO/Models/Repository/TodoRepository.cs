
using TODO.Data;

namespace TODO.Models.Repository
{
    public class TodoRepository : IRepository<Todo>
    {
        public AppDbContext Db { get; }

        public TodoRepository(AppDbContext db)
        {
            Db = db;
        }


        public void Add(Todo entity)
        {
            Db.todo.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, Todo entity)
        {
            var todo = Find(Id);
            if (todo != null)
            {
               Db.Remove(todo);
                Db.SaveChanges();
            }
            else
            {
                throw new Exception("Todo not found");
            }
        }

        public Todo Find(int Id)
        {
            return Db.todo.SingleOrDefault(x=> x.TodoId == Id); 

        }

        public void Update(int Id, Todo entity)
        {
            var todo = Find(Id);
            if (todo != null)
            {
                todo.TodoTitle = entity.TodoTitle;
                todo.TodoIsCompleted = entity.TodoIsCompleted;
                Db.SaveChanges();
            }
            else
            {
                throw new Exception("Todo not found");
            }
        }

        public List<Todo> View()
        {
            return Db.todo.ToList();    
        }
    }
}
