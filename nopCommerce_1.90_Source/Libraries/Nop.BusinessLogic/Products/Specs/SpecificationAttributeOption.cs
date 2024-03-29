﻿//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NopSolutions.NopCommerce.BusinessLogic.Infrastructure;

namespace NopSolutions.NopCommerce.BusinessLogic.Products.Specs
{
    /// <summary>
    /// Represents a specification attribute option
    /// </summary>
    public partial class SpecificationAttributeOption : BaseEntity
    {
        #region Fields
        private List<SpecificationAttributeOptionLocalized> _saoLocalized;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the specification attribute option identifier
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute identifier
        /// </summary>
        public int SpecificationAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion

        #region Localizable methods/properties

        /// <summary>
        /// Gets the localized name
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Localized name</returns>
        public string GetLocalizedName(int languageId)
        {
            if (NopContext.Current.LocalizedEntityPropertiesEnabled)
            {
                if (languageId > 0)
                {
                    if (_saoLocalized == null)
                        _saoLocalized = IoC.Resolve<ISpecificationAttributeService>().GetSpecificationAttributeOptionLocalizedBySpecificationAttributeOptionId(this.SpecificationAttributeOptionId);

                    var temp1 = _saoLocalized.FirstOrDefault(cl => cl.LanguageId == languageId);
                    if (temp1 != null && !String.IsNullOrWhiteSpace(temp1.Name))
                        return temp1.Name;
                }
            }

            return this.Name;
        }

        /// <summary>
        /// Gets the localized name 
        /// </summary>
        public string LocalizedName
        {
            get
            {
                return GetLocalizedName(NopContext.Current.WorkingLanguage.LanguageId);
            }
        }

        #endregion

        #region Custom Properties
        
        /// <summary>
        /// Gets the specification attribute
        /// </summary>
        public SpecificationAttribute SpecificationAttribute
        {
            get
            {
                return IoC.Resolve<ISpecificationAttributeService>().GetSpecificationAttributeById(this.SpecificationAttributeId);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets the specification attribute
        /// </summary>
        public virtual SpecificationAttribute NpSpecificationAttribute { get; set; }

        /// <summary>
        /// Gets the localized attribute option values
        /// </summary>
        public virtual ICollection<SpecificationAttributeOptionLocalized> NpSpecificationAttributeOptionLocalized { get; set; }
        
        
        /// <summary>
        /// Gets the product specification attribute
        /// </summary>
        public virtual ICollection<ProductSpecificationAttribute> NpProductSpecificationAttributes { get; set; }
        #endregion
    }
}
