using System.ComponentModel.DataAnnotations;

namespace HrWebApp.Models
{
    public class PersonalityTestModel
    {
        [Range(1, 5)]
        [Display(Name = "I enjoy trying new things and exploring different ideas.")]
        public int Question1 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I appreciate art, creativity, and unconventional thinking.")]
        public int Question2 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am open-minded and willing to consider alternative viewpoints.")]
        public int Question3 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am organized and prefer to plan ahead.")]
        public int Question4 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I pay attention to detail and strive for accuracy in my work.")]
        public int Question5 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I believe in following rules and regulations.")]
        public int Question6 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am outgoing and enjoy socializing with others.")]
        public int Question7 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I feel energized in group settings and enjoy being the center of attention.")]
        public int Question8 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am talkative and enjoy initiating conversations.")]
        public int Question9 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I value cooperation and harmony in team environments.")]
        public int Question10 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am empathetic and try to understand others' perspectives.")]
        public int Question11 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I prefer collaboration over competition.")]
        public int Question12 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I tend to worry about future uncertainties.")]
        public int Question13 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am sensitive to criticism and easily feel stressed.")]
        public int Question14 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I experience mood swings and emotional ups and downs.")]
        public int Question15 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am comfortable taking charge and making decisions.")]
        public int Question16 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I enjoy competition and strive to be in control of situations.")]
        public int Question17 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am assertive and direct in my communication style.")]
        public int Question18 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am persuasive and enjoy influencing others.")]
        public int Question19 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I thrive on social interactions and building relationships.")]
        public int Question20 { get; set; }
        [Range(1, 5)]
        [Display(Name = "I am enthusiastic and optimistic about new ideas.")]
        public int Question21 { get; set; }
    }
}
