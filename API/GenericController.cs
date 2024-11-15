using APPLICATION.IService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API;

/// <summary>
/// Generic Controller
/// </summary>
/// <typeparam name="TModel"></typeparam>
/// <typeparam name="IServiceProvider"></typeparam>
/// <typeparam name="ItemDto"></typeparam>
/// <typeparam name="GetDto"></typeparam>
public class GenericController <TModel, IServiceProvider, ItemDto, GetDto> : ControllerBase where IServiceProvider : IGenericService<TModel, GetDto>
{
    protected readonly IMapper _mapper;
    protected readonly IServiceProvider _repo;
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="repo"></param>
    public GenericController(IMapper mapper, IServiceProvider repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    /// <summary>
    /// Get all data.
    /// </summary>
    /// <returns></returns>
    protected async Task<ActionResult> GenericGetAll()
    {
        var result = /**/
            await _repo.GetAllAsync();

        return Ok(result);
    }
        
    /// <summary>
    /// Get all data by chunk.
    /// </summary>
    /// <param name="sizeMax"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericGetByChunk(int sizeMax)
    {
        var result = /**/
            await _repo.GetByChunk(sizeMax);

        return Ok(result);
    }

    /// <summary>
    /// Generic Get Action
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericGet(int id)
    {
        var result = /**/
            await _repo.GetAsync(id);

        return (result != null) 
            ? Ok(_mapper.Map<GetDto>(result))
            : NotFound();
    }

    /// <summary>
    /// Generic Create Action
    /// </summary>
    /// <typeparam name="ItemDto"></typeparam>
    /// <param name="newItem"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericCreate(ItemDto newItem)
    {
        var model = _mapper.Map<TModel>(newItem);

        var result = /**/
            await _repo.CreateAsync(model);

        return (result != null)
            ? Ok(result)
            : BadRequest("Something went wrong!");
    }

    /// <summary>
    /// Generic Create All Action
    /// </summary>
    /// <typeparam name="ItemDto"></typeparam>
    /// <param name="newItems"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericCreateAll(List<ItemDto> newItems)
    {
        var model = _mapper.Map<List<TModel>>(newItems);

        var result = /**/
            await _repo.CreateAllAsync(model);

        return (result != null)
            ? Ok(result)
            : BadRequest("Something went wrong!");
    }
    
    /// <summary>
    /// Generic Update Action
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericUpdate(int id, ItemDto item)
    {
        var record = await _repo.GetAsync(id);

        if (record == null)
        {
            return NotFound();
        }

        var model = _mapper.Map(item, record);

        var result = /**/
            await _repo.UpdateAsync(model);

        return (result != null)
            ? Ok(result)
            : BadRequest("Something went wrong!");
    }

    /// <summary>
    /// Generic Delete Action
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected async Task<ActionResult> GenericDelete(int id)
    {
        var record = await _repo.GetAsync(id);

        if (record == null)
        {
            return NotFound();
        }

        var result = /**/
            await _repo.DeleteSync(record);

        return (result)
            ? NoContent()
            : BadRequest("Something went wrong!");
    }
}