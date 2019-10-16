/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the <see cref="Person"/> detail entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class PersonDetail : Person
    {
        #region PropertyNames
      
        /// <summary>
        /// Represents the <see cref="History"/> property name.
        /// </summary>
        public const string Property_History = nameof(History);

        #endregion

        #region Privates

        private WorkHistoryCollection _history;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the History (see <see cref="WorkHistoryCollection"/>).
        /// </summary>
        [JsonProperty("history", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="History")]
        public WorkHistoryCollection History
        {
            get { return _history; }
            set { SetValue<WorkHistoryCollection>(ref _history, value, false, false, Property_History); }
        }

        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="PersonDetail"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="PersonDetail"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<PersonDetail>(from);
            CopyFrom((PersonDetail)fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="PersonDetail"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="PersonDetail"/> to copy from.</param>
        public void CopyFrom(PersonDetail from)
        {
            CopyFrom((Person)from);
            History = from.History;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="PersonDetail"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="PersonDetail"/>.</returns>
        public override object Clone()
        {
            var clone = new PersonDetail();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="PersonDetail"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            History = Cleaner.Clean(History);

            OnAfterCleanUp();
        }
    
        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                if (!base.IsInitial)
                    return false;

                return Cleaner.IsInitial(History);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void PersonDetailConstructor();

        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(PersonDetail from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="PersonDetail"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class PersonDetailCollection : EntityBaseCollection<PersonDetail>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailCollection"/> class.
        /// </summary>
        public PersonDetailCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="PersonDetail"/> entities.</param>
        public PersonDetailCollection(IEnumerable<PersonDetail> entities)
        {
            AddRange(entities);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="PersonDetailCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="PersonDetailCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new PersonDetailCollection();
            foreach (PersonDetail item in this)
            {
                clone.Add((PersonDetail)item.Clone());
            }
                
            return clone;
        }
        
        #endregion

        #region Operator

        /// <summary>
        /// An implicit cast from a <see cref="PersonDetailCollectionResult"/> to a <see cref="PersonDetailCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="PersonDetailCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="PersonDetailCollection"/>.</returns>
        public static implicit operator PersonDetailCollection(PersonDetailCollectionResult result)
        {
            return result?.Result;
        }

        #endregion
    }

    /// <summary>
    /// Represents a <see cref="PersonDetail"/> collection result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public class PersonDetailCollectionResult : EntityCollectionResult<PersonDetailCollection, PersonDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailCollectionResult"/> class.
        /// </summary>
        public PersonDetailCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailCollectionResult"/> class with default <see cref="PagingArgs"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public PersonDetailCollectionResult(PagingArgs paging) : base(paging) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDetailCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public PersonDetailCollectionResult(IEnumerable<PersonDetail> collection, PagingArgs paging = null) : base(paging)
        {
            Result.AddRange(collection);
        }
        
        /// <summary>
        /// Creates a deep copy of the <see cref="PersonDetailCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="PersonDetailCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new PersonDetailCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }
}
