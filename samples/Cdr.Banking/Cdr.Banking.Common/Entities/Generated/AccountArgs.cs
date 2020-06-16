/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options
#pragma warning disable CA2227, CA1819 // Collection/Array properties should be read only; ignored, as acceptable for a DTO.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Common.Entities
{
    /// <summary>
    /// Represents the <see cref="Account"/> arguments entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class AccountArgs : EntityBase, IEquatable<AccountArgs>
    {
        #region Privates

        private string? _productCategorySid;
        private string? _openStatusSid;
        private bool? _isOwned;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="ProductCategory"/> using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("product-category", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Product Category")]
        public string? ProductCategorySid
        {
            get => _productCategorySid;
            set => SetValue(ref _productCategorySid, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(ProductCategory));
        }

        /// <summary>
        /// Gets or sets the Product Category (see <see cref="RefDataNamespace.ProductCategory"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Product Category")]
        public RefDataNamespace.ProductCategory? ProductCategory
        {
            get => _productCategorySid;
            set => SetValue(ref _productCategorySid, value, false, false, nameof(ProductCategory)); 
        }

        /// <summary>
        /// Gets or sets the <see cref="OpenStatus"/> using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("open-status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Open Status")]
        public string? OpenStatusSid
        {
            get => _openStatusSid;
            set => SetValue(ref _openStatusSid, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(OpenStatus));
        }

        /// <summary>
        /// Gets or sets the Open Status (see <see cref="RefDataNamespace.OpenStatus"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Open Status")]
        public RefDataNamespace.OpenStatus? OpenStatus
        {
            get => _openStatusSid;
            set => SetValue(ref _openStatusSid, value, false, false, nameof(OpenStatus)); 
        }

        /// <summary>
        /// Gets or sets a value indicating whether Is Owned.
        /// </summary>
        [JsonProperty("is-owned", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Is Owned")]
        public bool? IsOwned
        {
            get => _isOwned;
            set => SetValue(ref _isOwned, value, false, false, nameof(IsOwned)); 
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is AccountArgs val))
                return false;

            return Equals(val);
        }

        /// <summary>
        /// Determines whether the specified <see cref="AccountArgs"/> is equal to the current <see cref="AccountArgs"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public bool Equals(AccountArgs? obj)
        {
            if (((object)obj!) == ((object)this))
                return true;
            else if (((object)obj!) == null)
                return false;

            return base.Equals((object)obj)
                && Equals(ProductCategorySid, obj.ProductCategorySid)
                && Equals(OpenStatusSid, obj.OpenStatusSid)
                && Equals(IsOwned, obj.IsOwned);
        }

        /// <summary>
        /// Compares two <see cref="AccountArgs"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="AccountArgs"/> A.</param>
        /// <param name="b"><see cref="AccountArgs"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (AccountArgs? a, AccountArgs? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="AccountArgs"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="AccountArgs"/> A.</param>
        /// <param name="b"><see cref="AccountArgs"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (AccountArgs? a, AccountArgs? b) => !Equals(a, b);

        /// <summary>
        /// Returns a hash code for the <see cref="AccountArgs"/>.
        /// </summary>
        /// <returns>A hash code for the <see cref="AccountArgs"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(ProductCategorySid);
            hash.Add(OpenStatusSid);
            hash.Add(IsOwned);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion
        
        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="AccountArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="AccountArgs"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<AccountArgs>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="AccountArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="AccountArgs"/> to copy from.</param>
        public void CopyFrom(AccountArgs from)
        {
             if (from == null)
                 throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            ProductCategorySid = from.ProductCategorySid;
            OpenStatusSid = from.OpenStatusSid;
            IsOwned = from.IsOwned;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="AccountArgs"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="AccountArgs"/>.</returns>
        public override object Clone()
        {
            var clone = new AccountArgs();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="AccountArgs"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            ProductCategorySid = Cleaner.Clean(ProductCategorySid);
            OpenStatusSid = Cleaner.Clean(OpenStatusSid);
            IsOwned = Cleaner.Clean(IsOwned);

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
                return Cleaner.IsInitial(ProductCategorySid)
                    && Cleaner.IsInitial(OpenStatusSid)
                    && Cleaner.IsInitial(IsOwned);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(AccountArgs from);

        #endregion
    } 
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore