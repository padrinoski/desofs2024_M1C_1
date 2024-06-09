namespace DESOFT.Server.API.Domain.Entities.Common
{
    public interface IAuditableEntity : IPartialAuditableEntity
    {
        /// <summary>
        /// Data de alteração do registo (auditoria).
        /// </summary>
        DateTime AlteracaoData { get; set; }

        /// <summary>
        /// Identificador do utilizador que alterou o registo (auditoria).
        /// </summary>
        string AlteracaoUtilizadorId { get; set; }
    }

    public interface IPartialAuditableEntity
    {
        /// <summary>
        /// Data de criação do registo (auditoria).
        /// </summary>
        DateTime CriacaoData { get; set; }

        /// <summary>
        /// Identificador do utilizador que criou o registo (auditoria).
        /// </summary>
        string CriacaoUtilizadorId { get; set; }
    }

    public abstract class AuditableEntity : PartialAuditableEntity, IAuditableEntity
    {
        /// <summary>
        /// Data de alteração do registo (auditoria).
        /// </summary>
        public DateTime AlteracaoData { get; set; }

        /// <summary>
        /// Identificador do utilizador que alterou o registo (auditoria).
        /// </summary>
        public string AlteracaoUtilizadorId { get; set; }

    }

    public abstract class PartialAuditableEntity : IPartialAuditableEntity
    {
        /// <summary>
        /// Data de criação do registo (auditoria).
        /// </summary>
        public DateTime CriacaoData { get; set; }

        /// <summary>
        /// Identificador do utilizador que criou o registo (auditoria).
        /// </summary>
        public string CriacaoUtilizadorId { get; set; }

    }
}
