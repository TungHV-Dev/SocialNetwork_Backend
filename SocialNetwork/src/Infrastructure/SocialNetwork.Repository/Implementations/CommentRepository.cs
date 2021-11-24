using SocialNetwork.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SocialNetwork.Repository.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public CommentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region Public Functions

        #endregion
    }
}
