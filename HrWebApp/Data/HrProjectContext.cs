using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HrWebApp.Data;

public partial class HrProjectContext : DbContext
{
    public HrProjectContext()
    {
    }

    public HrProjectContext(DbContextOptions<HrProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanySector> CompanySectors { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<PersonalityTest> PersonalityTests { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentStatistic> StudentStatistics { get; set; }

    public virtual DbSet<StudentStatus> StudentStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCategory> UserCategories { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Desktop-26v0glf;Database=HrProject;Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Companie__3E2672356BCB3D1F");

            entity.HasIndex(e => e.CompanyUrl, "UQ__Companie__A2CD6A7A1B8DDC05").IsUnique();

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyDateOfCreation).HasColumnName("company_date_of_creation");
            entity.Property(e => e.CompanyDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("company_description");
            entity.Property(e => e.CompanyLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_location");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyNumberOfEmployees).HasColumnName("company_number_of_employees");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_phone");
            entity.Property(e => e.CompanyRecruiterFirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_recruiterFirstName");
            entity.Property(e => e.CompanyRecruiterLastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_recruiterLastName");
            entity.Property(e => e.CompanySectorId).HasColumnName("companySector_id");
            entity.Property(e => e.CompanyTypeId).HasColumnName("companyType_id");
            entity.Property(e => e.CompanyUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_url");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CompanySector).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanySectorId)
                .HasConstraintName("FK__Companies__compa__6FE99F9F");

            entity.HasOne(d => d.CompanyType).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanyTypeId)
                .HasConstraintName("FK__Companies__compa__70DDC3D8");

            entity.HasOne(d => d.User).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Companies__user___71D1E811");
        });

        modelBuilder.Entity<CompanySector>(entity =>
        {
            entity.HasKey(e => e.CompanySectorId).HasName("PK__CompanyS__511940AE643FEF1F");

            entity.Property(e => e.CompanySectorId).HasColumnName("companySector_id");
            entity.Property(e => e.CompanySectorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companySector_name");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.CompanyTypeId).HasName("PK__CompanyT__ADA69C8A54C7D679");

            entity.Property(e => e.CompanyTypeId).HasColumnName("companyType_id");
            entity.Property(e => e.CompanyTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyType_name");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__F8D6642351B36139");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ContractTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contract_title");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__45C0CFE7BB847365");

            entity.Property(e => e.EducationId).HasColumnName("education_id");
            entity.Property(e => e.EducationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("education_name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__804CF6B3C2154534");

            entity.HasIndex(e => e.LanguageName, "UQ__Language__9CE82383929CE326").IsUnique();

            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LanguageName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("language_name");
        });

        modelBuilder.Entity<PersonalityTest>(entity =>
        {
            entity.HasKey(e => e.PersonalityTestId).HasName("PK__Personal__258BC9E88C061A76");

            entity.Property(e => e.PersonalityTestId).HasColumnName("personalityTest_id");
            entity.Property(e => e.PersonalityTestQuestion1).HasColumnName("personalityTest_question1");
            entity.Property(e => e.PersonalityTestQuestion10).HasColumnName("personalityTest_question10");
            entity.Property(e => e.PersonalityTestQuestion11).HasColumnName("personalityTest_question11");
            entity.Property(e => e.PersonalityTestQuestion12).HasColumnName("personalityTest_question12");
            entity.Property(e => e.PersonalityTestQuestion13).HasColumnName("personalityTest_question13");
            entity.Property(e => e.PersonalityTestQuestion14).HasColumnName("personalityTest_question14");
            entity.Property(e => e.PersonalityTestQuestion15).HasColumnName("personalityTest_question15");
            entity.Property(e => e.PersonalityTestQuestion16).HasColumnName("personalityTest_question16");
            entity.Property(e => e.PersonalityTestQuestion17).HasColumnName("personalityTest_question17");
            entity.Property(e => e.PersonalityTestQuestion18).HasColumnName("personalityTest_question18");
            entity.Property(e => e.PersonalityTestQuestion19).HasColumnName("personalityTest_question19");
            entity.Property(e => e.PersonalityTestQuestion2).HasColumnName("personalityTest_question2");
            entity.Property(e => e.PersonalityTestQuestion20).HasColumnName("personalityTest_question20");
            entity.Property(e => e.PersonalityTestQuestion21).HasColumnName("personalityTest_question21");
            entity.Property(e => e.PersonalityTestQuestion3).HasColumnName("personalityTest_question3");
            entity.Property(e => e.PersonalityTestQuestion4).HasColumnName("personalityTest_question4");
            entity.Property(e => e.PersonalityTestQuestion5).HasColumnName("personalityTest_question5");
            entity.Property(e => e.PersonalityTestQuestion6).HasColumnName("personalityTest_question6");
            entity.Property(e => e.PersonalityTestQuestion7).HasColumnName("personalityTest_question7");
            entity.Property(e => e.PersonalityTestQuestion8).HasColumnName("personalityTest_question8");
            entity.Property(e => e.PersonalityTestQuestion9).HasColumnName("personalityTest_question9");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PersonalityTests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPersonalityTest");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__FBBA837961E5A9A8");

            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069A9445901F");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.EducationAverageScore).HasColumnName("education_averageScore");
            entity.Property(e => e.StudentAwardsHonors)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("student_awards_honors");
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_first_name");
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_last_name");
            entity.Property(e => e.StudentNumberProjects).HasColumnName("student_number_projects");
            entity.Property(e => e.StudentPhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("student_phone_number");
            entity.Property(e => e.StudentStatusId).HasColumnName("student_status_id");
            entity.Property(e => e.StudentUrlGithub)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("student_url_github");
            entity.Property(e => e.StudentWorkExperience).HasColumnName("student_work_experience");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.StudentStatus).WithMany(p => p.Students)
                .HasForeignKey(d => d.StudentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__studen__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__user_i__6B24EA82");

            entity.HasMany(d => d.Educations).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentsEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___educa__5EBF139D"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___stude__5DCAEF64"),
                    j =>
                    {
                        j.HasKey("StudentId", "EducationId");
                        j.ToTable("Students_Educations");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("EducationId").HasColumnName("education_id");
                    });

            entity.HasMany(d => d.Languages).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentsLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___langu__628FA481"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___stude__619B8048"),
                    j =>
                    {
                        j.HasKey("StudentId", "LanguageId");
                        j.ToTable("Students_Languages");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("language_id");
                    });

            entity.HasMany(d => d.Skills).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentsSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___skill__5AEE82B9"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Students___stude__59FA5E80"),
                    j =>
                    {
                        j.HasKey("StudentId", "SkillId");
                        j.ToTable("Students_Skills");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                    });

            entity.HasMany(d => d.Vacancies).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentVacancy",
                    r => r.HasOne<Vacancy>().WithMany()
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_V__vacan__208CD6FA"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_V__stude__1F98B2C1"),
                    j =>
                    {
                        j.HasKey("StudentId", "VacancyId");
                        j.ToTable("Student_Vacancies");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("VacancyId").HasColumnName("vacancy_id");
                    });
        });

        modelBuilder.Entity<StudentStatistic>(entity =>
        {
            entity.HasKey(e => e.StatisticId).HasName("PK__StudentS__770EBB1D49A4CF4E");

            entity.Property(e => e.StatisticId).HasColumnName("statistic_id");
            entity.Property(e => e.EducationScore).HasColumnName("education_score");
            entity.Property(e => e.IndividualAchievementsScore).HasColumnName("individualAchievements_score");
            entity.Property(e => e.PersonalityTestScore).HasColumnName("personalityTest_score");
            entity.Property(e => e.ProfilScore).HasColumnName("profil_score");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentStatistics)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentSt__stude__7F2BE32F");
        });

        modelBuilder.Entity<StudentStatus>(entity =>
        {
            entity.HasKey(e => e.StudentStatusId).HasName("PK__Student___76E8051A6CA8F9F8");

            entity.ToTable("Student_Status");

            entity.Property(e => e.StudentStatusId).HasColumnName("student_status_id");
            entity.Property(e => e.StudentStatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FA2982F73");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__B0FBA2126917E4F8").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserCategoryId).HasColumnName("user_category_id");
            entity.Property(e => e.UserConfirmationPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_confirmation_password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");

            entity.HasOne(d => d.UserCategory).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserCategoryId)
                .HasConstraintName("FK__Users__user_cate__6A30C649");
        });

        modelBuilder.Entity<UserCategory>(entity =>
        {
            entity.HasKey(e => e.UserCategoryId).HasName("PK__User_Cat__6E36C73B1048CE18");

            entity.ToTable("User_Categories");

            entity.Property(e => e.UserCategoryId).HasColumnName("user_category_id");
            entity.Property(e => e.UserCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_category_name");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.VacancyId).HasName("PK__Vacancie__C04F3A666DAC363E");

            entity.Property(e => e.VacancyId).HasColumnName("vacancy_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("datetime")
                .HasColumnName("publication_date");
            entity.Property(e => e.Responsibilities)
                .HasColumnType("text")
                .HasColumnName("responsibilities");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
            entity.Property(e => e.StudyLevelId).HasColumnName("study_level_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.VacancyDescription)
                .HasColumnType("text")
                .HasColumnName("vacancy_description");
            entity.Property(e => e.WorkingExperience).HasColumnName("working_experience");
            entity.Property(e => e.WorkingHours).HasColumnName("working_hours");

            entity.HasOne(d => d.Company).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancies__compa__44FF419A");

            entity.HasOne(d => d.Contract).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancies__contr__47DBAE45");

            entity.HasOne(d => d.StudyLevel).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.StudyLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancies__study__282DF8C2");

            entity.HasMany(d => d.Skills).WithMany(p => p.Vacancies)
                .UsingEntity<Dictionary<string, object>>(
                    "VacancySkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Vacancy_S__skill__1CBC4616"),
                    l => l.HasOne<Vacancy>().WithMany()
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Vacancy_S__vacan__1BC821DD"),
                    j =>
                    {
                        j.HasKey("VacancyId", "SkillId").HasName("PK_Vacancies_Skills");
                        j.ToTable("Vacancy_Skills");
                        j.IndexerProperty<int>("VacancyId").HasColumnName("vacancy_id");
                        j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                    });

            entity.HasMany(d => d.Statistics).WithMany(p => p.Vacancies)
                .UsingEntity<Dictionary<string, object>>(
                    "VacancyStudentStatistic",
                    r => r.HasOne<StudentStatistic>().WithMany()
                        .HasForeignKey("StatisticId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Vacancy_S__stati__245D67DE"),
                    l => l.HasOne<Vacancy>().WithMany()
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Vacancy_S__vacan__236943A5"),
                    j =>
                    {
                        j.HasKey("VacancyId", "StatisticId");
                        j.ToTable("Vacancy_StudentStatistics");
                        j.IndexerProperty<int>("VacancyId").HasColumnName("vacancy_id");
                        j.IndexerProperty<int>("StatisticId").HasColumnName("statistic_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
