using System.Collections.Generic;
using Iconiz.Boilerplate.Auditing.Dto;
using Iconiz.Boilerplate.Dto;

namespace Iconiz.Boilerplate.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
