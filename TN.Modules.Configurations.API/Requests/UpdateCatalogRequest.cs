﻿using TN.Modules.Buildings.Shared.Api;

namespace TN.Modules.Configurations.API.Requests
{
    public sealed record UpdateCatalogRequest (
        Guid Id,
        string Type,
        string Value,
        bool Editable,
        bool Enabled,
        int? Int1,
        int? Int2,
        string Nvarchar1,
        string Nvarchar2,
        string Nvarchar3,
        string Nvarchar4,
        string Nvarchar5,
        bool? Bool1,
        decimal? Decimal1,
        decimal? Decimal2,
        byte[] RowVersion) : BaseRequest;
}
