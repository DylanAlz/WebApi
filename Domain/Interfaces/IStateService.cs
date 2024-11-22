﻿using WebAPI.DAL.Entities;
namespace WebAPI.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> CreateStateAsync(Country country, State state);
        Task<State> DeleteStateAsync(Guid id);
        Task<State> EditStateAsync(Country country, State state);

    }
}
