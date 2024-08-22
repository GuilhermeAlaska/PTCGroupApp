namespace Domain.Models
{
    public class Notification
    {
        public Notification(string title)
        {
            Text = $"Novo post criado às {DateTime.Now.ToString("HH:ss")}. Título: {title}";
        }

        public string Text { get; set; }
    }
}