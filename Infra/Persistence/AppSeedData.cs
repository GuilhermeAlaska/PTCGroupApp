using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence
{
    public static class AppSeedData
    {
        public static ModelBuilder AppSeedDataBaseConstructor(this ModelBuilder modelBuilder)
        {
            var createAt = new DateTime(2023, 10, 10, 12, 00, 00, DateTimeKind.Utc);

            var posts = new List<Post>
            {
            new Post(
                "Melhores Práticas de Software",
                "Práticas para um software eficiente.",
                "O desenvolvimento de software é...",
                Category.DesenvolvimentoSoftware
            ),
            new Post(
                "O Futuro da IA",
                "Impacto da IA na tecnologia.",
                "A IA está transformando o mundo...",
                Category.InteligenciaArtificial
            ),
            new Post(
                "Tendências de Hardware em 2024",
                "As maiores tendências em hardware.",
                "Novas tecnologias estão surgindo...",
                Category.Hardware
            ),
            new Post(
                "Desenvolvimento Mobile",
                "Tendências em desenvolvimento mobile.",
                "O desenvolvimento mobile está evoluindo...",
                Category.ProgramacaoMobile
            ),
            new Post(
                "DevOps na Prática",
                "Como aplicar DevOps em seu projeto.",
                "DevOps está mudando a forma como...",
                Category.DevOps
            ),
            new Post(
                "Tutorial de C# para Iniciantes",
                "Aprenda C# do zero com este tutorial.",
                "Comece com os fundamentos do C#...",
                Category.Tutoriais
            ),
            new Post(
                "Notícias da Semana",
                "As principais notícias de tecnologia.",
                "Nesta semana, grandes eventos...",
                Category.Noticias
            )
            };

            modelBuilder.Entity<Post>().HasData(posts);

            return modelBuilder;
        }
    }
}