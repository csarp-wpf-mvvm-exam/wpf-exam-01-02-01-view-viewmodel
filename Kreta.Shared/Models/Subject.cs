﻿namespace Kreta.Shared.Models
{
    public class Subject : IDbEntity<Subject>
    {
        public Subject()
        {
            Id = Guid.Empty;
            SubjectTypeId = Guid.Empty;
            SubjectName = string.Empty;
            ShortName = string.Empty;
            OptionalExaminationSubject = false;
            CompulsoryExaminationSubject = false;
        }

        public Subject(Guid id, Guid subjectTypeId, string subjectName, string shortName, bool optionalExaminationSubject, bool compulsoryExaminationSubject)
        {
            Id = id;
            SubjectTypeId = subjectTypeId;
            SubjectName = subjectName;
            ShortName = shortName;
            OptionalExaminationSubject = optionalExaminationSubject;
            CompulsoryExaminationSubject = compulsoryExaminationSubject;
        }

        public Guid Id { get; set; }
        public Guid? SubjectTypeId { get; set; }
        public string SubjectName { get; set; }
        public string ShortName { get; set; }
        public bool OptionalExaminationSubject { get; set; }
        public bool CompulsoryExaminationSubject { get; set; }

        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{SubjectName}";
        }

    }
}
