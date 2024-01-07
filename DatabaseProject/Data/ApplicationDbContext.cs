using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<CoSupervisor> CoSupervisors { get; set; } = null!;
        public virtual DbSet<Institute> Institutes { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<SubjectTopic> SubjectTopics { get; set; } = null!;
        public virtual DbSet<Supervisor> Supervisors { get; set; } = null!;
        public virtual DbSet<TSubject> TSubjects { get; set; } = null!;
        public virtual DbSet<Thesis> Theses { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("author_id");

                entity.Property(e => e.AuthorAge).HasColumnName("author_age");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("author_name");

                entity.Property(e => e.AuthorSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("author_surname");
            });

            modelBuilder.Entity<CoSupervisor>(entity =>
            {
                entity.HasKey(e => e.CoSupervisorId)
                    .HasName("PK__co_super__CB64971F52E984BA");

                entity.ToTable("co_supervisors");

                entity.Property(e => e.CoSupervisorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("co_sup_id");

                entity.Property(e => e.CoSupervisorAge).HasColumnName("co_sup_age");

                entity.Property(e => e.CoSupervisorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("co_sup_name");

                entity.Property(e => e.CoSupervisorSurname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("co_sup_surname");
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.HasKey(e => e.InstituteId)
                    .HasName("PK__institut__9CB72D20BE7905B8");

                entity.ToTable("institutes");

                entity.Property(e => e.InstituteId).HasColumnName("ins_id");

                entity.Property(e => e.InstituteName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ins_name");

                entity.Property(e => e.UniversityId).HasColumnName("uni_id");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Institutes)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__institute__uni_i__7F2BE32F");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.KeywordId)
                    .HasName("PK__keywords__97DF9ACD6DA19E79");

                entity.ToTable("keywords");

                entity.Property(e => e.KeywordId)
                    .ValueGeneratedNever()
                    .HasColumnName("key_id");

                entity.Property(e => e.KeywordName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("key_name");

                entity.Property(e => e.ThesisNo).HasColumnName("thesis_no");

                entity.HasOne(d => d.Thesis)
                    .WithMany(p => p.Keywords)
                    .HasForeignKey(d => d.ThesisNo)
                    .HasConstraintName("FK__keywords__thesis__0A9D95DB");
            });

            modelBuilder.Entity<SubjectTopic>(entity =>
            {
                entity.HasKey(e => e.SubjectTopicId)
                    .HasName("PK__subject___A85E81CF42660A42");

                entity.ToTable("subject_topics");

                entity.Property(e => e.SubjectTopicId)
                    .ValueGeneratedNever()
                    .HasColumnName("st_id");

                entity.Property(e => e.SubjectTopicName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("st_name");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => e.SupervisorId)
                    .HasName("PK__supervis__FB8F785F52102143");

                entity.ToTable("supervisors");

                entity.Property(e => e.SupervisorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("sup_id");

                entity.Property(e => e.SupervisorAge).HasColumnName("sup_age");

                entity.Property(e => e.SupervisorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sup_name");

                entity.Property(e => e.SupervisorSurname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sup_surname");
            });

            modelBuilder.Entity<TSubject>(entity =>
            {
                entity.ToTable("t_subjects");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.SubjectTopicId).HasColumnName("st_id");

                entity.Property(e => e.ThesisNo).HasColumnName("thesis_no");

                entity.HasOne(d => d.SubjectTopic)
                    .WithMany(p => p.TSubjects)
                    .HasForeignKey(d => d.SubjectTopicId)
                    .HasConstraintName("FK__t_subject__st_id__10566F31");

                entity.HasOne(d => d.Thesis)
                    .WithMany(p => p.TSubjects)
                    .HasForeignKey(d => d.ThesisNo)
                    .HasConstraintName("FK__t_subject__thesi__0F624AF8");
            });

            modelBuilder.Entity<Thesis>(entity =>
            {
                entity.HasKey(e => e.ThesisNo)
                    .HasName("PK__thesis__50ACADFD0B7433F7");

                entity.ToTable("thesis");

                entity.Property(e => e.ThesisNo).HasColumnName("thesis_no");

                entity.Property(e => e.Abstract)
                    .HasColumnType("text")
                    .HasColumnName("abstract");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("author_id");

                entity.Property(e => e.CoSupervisorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("co_sup_id");

                entity.Property(e => e.InstitueId).HasColumnName("ins_id");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.NumPages).HasColumnName("num_pages");

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("date")
                    .HasColumnName("submission_date");

                entity.Property(e => e.SupervisorId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("sup_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UniversityId).HasColumnName("uni_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Theses)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thesis__author_i__03F0984C");

                entity.HasOne(d => d.CoSupervisor)
                    .WithMany(p => p.Theses)
                    .HasForeignKey(d => d.CoSupervisorId)
                    .HasConstraintName("FK__thesis__co_sup_i__07C12930");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Theses)
                    .HasForeignKey(d => d.InstitueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thesis__ins_id__05D8E0BE");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.Theses)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK__thesis__sup_id__06CD04F7");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Theses)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thesis__uni_id__04E4BC85");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.UniversityId)
                    .HasName("PK__universi__5D928CDE0B495EF1");

                entity.ToTable("university");

                entity.Property(e => e.UniversityId).HasColumnName("uni_id");

                entity.Property(e => e.UniversityAddress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("uni_address");

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uni_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
