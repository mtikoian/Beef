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
    /// Represents the Work History entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class WorkHistory : EntityBase
    {
        #region PropertyNames
      
        /// <summary>
        /// Represents the <see cref="PersonId"/> property name.
        /// </summary>
        public const string Property_PersonId = nameof(PersonId);

        /// <summary>
        /// Represents the <see cref="Name"/> property name.
        /// </summary>
        public const string Property_Name = nameof(Name);

        /// <summary>
        /// Represents the <see cref="StartDate"/> property name.
        /// </summary>
        public const string Property_StartDate = nameof(StartDate);

        /// <summary>
        /// Represents the <see cref="EndDate"/> property name.
        /// </summary>
        public const string Property_EndDate = nameof(EndDate);

        #endregion

        #region Privates

        private Guid _personId;
        private string _name;
        private DateTime _startDate;
        private DateTime? _endDate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Person"/> identifier (not serialized/read-only for internal data merging).
        /// </summary>
        [Display(Name="Person")]
        public Guid PersonId
        {
            get { return _personId; }
            set { SetValue<Guid>(ref _personId, value, true, false, Property_PersonId); }
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Name")]
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_Name); }
        }

        /// <summary>
        /// Gets or sets the Start Date.
        /// </summary>
        [JsonProperty("startDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Start Date")]
        [DisplayFormat(DataFormatString = Beef.Entities.StringFormat.DateOnlyFormat)]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetValue(ref _startDate, value, false, DateTimeTransform.DateOnly, Property_StartDate); }
        }

        /// <summary>
        /// Gets or sets the End Date.
        /// </summary>
        [JsonProperty("endDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="End Date")]
        [DisplayFormat(DataFormatString = Beef.Entities.StringFormat.DateOnlyFormat)]
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { SetValue(ref _endDate, value, false, DateTimeTransform.DateOnly, Property_EndDate); }
        }

        #endregion

        #region UniqueKey
      
        /// <summary>
        /// Indicates whether the <see cref="WorkHistory"/> has a <see cref="UniqueKey"/> value.
        /// </summary>
        public override bool HasUniqueKey
        {
            get { return true; }
        }
        
        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public override string[] UniqueKeyProperties => new string[] { Property_Name };
        
        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="name">The <see cref="Name"/>.</param>
        public static UniqueKey CreateUniqueKey(string name)
        {
            return new UniqueKey(name);
        }
          
        /// <summary>
        /// Gets the <see cref="UniqueKey"/>.
        /// </summary>
        /// <remarks>
        /// The <b>UniqueKey</b> key consists of the following property(s): <see cref="Name"/>.
        /// </remarks>
        public override UniqueKey UniqueKey
        {
            get { return new UniqueKey(Name); }
        }

        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="WorkHistory"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="WorkHistory"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<WorkHistory>(from);
            CopyFrom((WorkHistory)fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="WorkHistory"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="WorkHistory"/> to copy from.</param>
        public void CopyFrom(WorkHistory from)
        {
            CopyFrom((EntityBase)from);
            PersonId = from.PersonId;
            Name = from.Name;
            StartDate = from.StartDate;
            EndDate = from.EndDate;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="WorkHistory"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="WorkHistory"/>.</returns>
        public override object Clone()
        {
            var clone = new WorkHistory();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="WorkHistory"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Name = Cleaner.Clean(Name, StringTrim.End, StringTransform.EmptyToNull);
            StartDate = Cleaner.Clean(StartDate, DateTimeTransform.DateOnly);
            EndDate = Cleaner.Clean(EndDate, DateTimeTransform.DateOnly);

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
                return Cleaner.IsInitial(Name)
                    && Cleaner.IsInitial(StartDate)
                    && Cleaner.IsInitial(EndDate);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void WorkHistoryConstructor();

        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(WorkHistory from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="WorkHistory"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class WorkHistoryCollection : EntityBaseCollection<WorkHistory>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkHistoryCollection"/> class.
        /// </summary>
        public WorkHistoryCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkHistoryCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="WorkHistory"/> entities.</param>
        public WorkHistoryCollection(IEnumerable<WorkHistory> entities)
        {
            AddRange(entities);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="WorkHistoryCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="WorkHistoryCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new WorkHistoryCollection();
            foreach (WorkHistory item in this)
            {
                clone.Add((WorkHistory)item.Clone());
            }
                
            return clone;
        }
        
        #endregion
    }
}
