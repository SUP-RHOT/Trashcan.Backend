using Trashcan.Domain.Entities.BaseEntity;


namespace Trashcan.Domain.Entity
{
	public class Actor : IBaseEntity<int>
	{
		public int Id { get; set; }

		public char Lastname { get; set; }

		public char Firstname { get; set; }

		public char Secondname { get; set; }

		public char PhoneNumber { get; set; }

		public char Email { get; set; }

		public char City { get; set; }

		public char Street { get; set; }

		public char House { get; set; }

		public char Apartament { get; set; }

		public char Login { get; set; }

		public char Password { get; set; }

		public bool Status { get; set; }

		public bool Mailing { get; set; }
	}
}
