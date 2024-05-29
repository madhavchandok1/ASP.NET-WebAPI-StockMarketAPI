using api.Dtos.Comments;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;

        public CommentsController(ICommentsRepository commentsRepository, IStockRepository stockRepository, UserManager<AppUser>userManager)
        {
            _commentsRepository = commentsRepository;
            _stockRepository = stockRepository;
            _userManager = userManager;
        }

        //GET: api/comments
        [HttpGet]
        public async Task<IActionResult> GetComments([FromQuery]CommentQueryObject query)
        {
            var comments = await _commentsRepository.GetAllAsync(query);
            var commentsDto = comments.Select(row => row.toCommentsDto());
            if(commentsDto == null)
                return NotFound("No comment found");
            return Ok(commentsDto);
        }

        //GET: api/comments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute]int id)
        {
            var comment = await _commentsRepository.GetByIdAsync(id);
            
            if (comment == null)
                return NotFound($"Comment not found with id {id}");
            
            return Ok(comment.toCommentsDto());
        }

        //POST: api/comments/create/{stockId}
        [HttpPost]
        [Route("create/{stockId}")]
        public async Task<IActionResult> CreateComment([FromRoute]int stockId, [FromBody]CreateCommentDto createCommentDto)
        {
            if (!await _stockRepository.IsStockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var username = User.GetUsername(); 
            var appUser = await _userManager.FindByNameAsync(username);
            var comment = createCommentDto.fromCreateToComment(stockId, appUser.Id);

            await _commentsRepository.CreateAsync(comment);
            
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.toCommentsDto());
        }

        //PUT: api/comments/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute]int id, [FromBody]UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentsRepository.UpdateAsync(id, updateCommentDto.fromUpdateToComment());
            if (comment == null)
                return NotFound($"Comment not found with id {id}");
            
            return Ok(comment.toCommentsDto());
        }

        //DELETE: api/comments/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute]int id)
        {
            var comment = await _commentsRepository.DeleteAsync(id);
            
            if (comment == null)
                return NotFound($"Comment not found with id {id}");

            return Ok(comment.toCommentsDto());
        }
    }
}

