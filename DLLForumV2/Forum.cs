using Common;
using DALClientWS;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe principale, elle est instanciée à l'ouverture de l'application
    /// </summary>
    public class Forum
    {
        /// <summary>
        /// Utilisateur de la session
        /// </summary>
        public Registered User { get; set; }
        /// <summary>
        /// Jeton pour authentifier l'utilisateur
        /// </summary>
        public Token TokenUser { get; set; }
        /// <summary>
        /// Liste des rubriques
        /// </summary>
        public List<Rubric> ListRubric { get; set; }
        /// <summary>
        /// Liste des statuts
        /// </summary>
        public List<Status> ListStatus { get; set; }
        /// <summary>
        /// Liste des formations
        /// </summary>
        public List<Training> ListTraining { get; set; }
        /// <summary>
        /// Permet l'accès aux ressources du web service
        /// </summary>
        public DALClient dal { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Forum()
        {
            dal = new DALClient();
            User = new Registered();
            TokenUser = new Token();
            ListRubric = new List<Rubric>();
            ListTraining = new List<Training>();
            ListStatus = new List<Status>();
            GetListRubrics();
            GetListStatus();
            GetListtraining();
        }

        /// <summary>
        /// Constructeur pour une session
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        public Forum(Registered user, Token token) : this()
        {
            User = user;
            TokenUser = token;
        }

        /// <summary>
        /// Méthode pour obtenir la liste des rubriques
        /// </summary>
        public void GetListRubrics()
        {
            DALWSR_Result r1 = dal.GetListRubricsAsync(CancellationToken.None);
            if(r1.Data != null)
            {
                foreach (RubricDTO item in (List<RubricDTO>)r1.Data)
                {
                    ListRubric.Add(new Rubric(item));
                }
            }
        }

        /// <summary>
        /// Méthode pour obtenir la liste des statuts
        /// </summary>
        public void GetListStatus()
        {
            DALWSR_Result r1 = dal.GetListStatus(CancellationToken.None);
            if(r1.Data != null)
            {
                foreach (StatusDTO item in (List<StatusDTO>)r1.Data)
                {
                    ListStatus.Add(new Status(item));
                }
            }
            
        }

        /// <summary>
        /// Méthode pour obtenir la liste des formations
        /// </summary>
        public void GetListtraining()
        {
            DALWSR_Result r1 = dal.GetListTrainings(CancellationToken.None);
            if (r1.Data != null)
            {
                foreach (TrainingDTO item in (List<TrainingDTO>)r1.Data)
                {
                    ListTraining.Add(new Training(item));
                }
            }
            
        }
    }
}
