using Adboard.Contracts.Users;
using Adboard.Domain.Entities;
using Ardalis.Specification;

namespace Adboard.AppServices.Contexts.Users.Specifications;

public class UserFilterSpecification : Specification<User>
{
    public UserFilterSpecification(UserFilterDto filter)
    {
        Query.OrderBy(x => x.Id);
        
        if (!string.IsNullOrEmpty(filter.FirstName))
        {
            Query.Search(c => c.FirstName, "%" + filter.FirstName + "%");
        }

        if (!string.IsNullOrEmpty(filter.MiddleName))
        {
            Query.Search(c => c.MiddleName, "%" + filter.MiddleName + "%");
        }

        if (!string.IsNullOrEmpty(filter.LastName))
        {
            Query.Search(c => c.LastName,  "%" + filter.LastName + "%");
        }
        
        if (!string.IsNullOrEmpty(filter.PhoneNumber))
        {
            Query.Search(c => c.PhoneNumber, "%" + filter.PhoneNumber + "%");
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            Query.Search(c => c.Email, "%" + filter.Email + "%");
        }

        if (!string.IsNullOrWhiteSpace(filter.Role))
        {
            Query.Search(c => c.Role.Title, "%" + filter.Role + "%");
        }

        if (filter.AccountStatus != null)
        {
            Query.Where(u => u.AccountStatus.Id == filter.AccountStatus);
        }

        Query.Include(c => c.Role);
        Query.Include(c => c.AccountStatus);
        
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}