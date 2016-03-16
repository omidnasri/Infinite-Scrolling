using System.ComponentModel.DataAnnotations.Schema;

namespace Paging.Models
{
    /// <summary>
    /// جدول اشخاص
    /// </summary>
    [Table(name: "Persons")]
    public class Persons
    {
        #region Properties
        /// <summary>
        /// کلید جدول
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender { get; set; }
        #endregion
    }
}