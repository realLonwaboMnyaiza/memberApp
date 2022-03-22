using app.DAL;
using app.Dtos;
using app.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace app.Controllers.Tests
{
    [TestFixture]
    public class MemberControllerTests
    {
        [TestFixture]
        public class GetMemberTests
        {
            [Test]
            public async Task ShouldReturn404IfMemberIsNotFound()
            {
                // arrange.
                var repository = new Mock<IMemberRepository>();
                repository.Setup(m => m.GetMember(It.IsAny<int>()))
                   .ReturnsAsync(default(Member));
                var memberController = Create(repository: repository.Object);

                // act.
                var result = await memberController.GetMember(It.IsAny<int>());

                // assert. 
                Assert.That((result as NotFoundResult)?.StatusCode,
                    Is.EqualTo(404));
            }

            [Test]
            public async Task ShouldReturn200WhenGettingMembers()
            {
                // arrange.
                var memberId = 1;
                var member = CreateMember(id: memberId);
                var memberRepository = new Mock<IMemberRepository>();
                memberRepository.Setup(m => m.GetMember(memberId))
                    .ReturnsAsync(member);
                var memberController = Create(repository: memberRepository.Object);

                // act.
                var result = await memberController.GetMember(memberId);

                // assert.
                Assert.That((result as OkObjectResult)?.StatusCode,
                    Is.EqualTo(200));
            }

            [Test]
            public async Task ShouldReturnMemberFromDataStore()
            {
                // arrange.
                var memberId = 1;
                var members = CreateMembers(1);
                // fix: potential bug this might not ref to the same member (id)
                var member = members.SingleOrDefault(m => m.Id == memberId);
                var memberRepository = new Mock<IMemberRepository>();
                memberRepository.Setup(m => m.GetMember(memberId))
                    .ReturnsAsync(member);

                var mapper = new Mock<IMapper>();
                mapper.Setup(m => m.Map<MemberDto>(member))
                    .Returns(ConvertMemberToDto(member));

                var memberController = Create(
                    repository: memberRepository.Object,
                    mapper: mapper.Object);

                // act.
                var result = await memberController.GetMember(memberId);

                // assert.
                Assert.That(((result as OkObjectResult)?.Value as MemberDto).FirstName,
                    Is.EqualTo(member.FirstName));
            }

            [Test]
            public async Task ShouldReturnStatusCode500WhenExceptionOccurs()
            {
                // arrange.
                var memberId = 1;
                var memberRepository = new Mock<IMemberRepository>();
                memberRepository.Setup(m => m.GetMember(memberId))
                    .Throws(new IOException());
                var memberController = Create(repository: memberRepository.Object);

                // act.
                var result = await memberController.GetMember(memberId);

                // assert.
                Assert.That((result as StatusCodeResult)?.StatusCode,
                    Is.EqualTo(500));
            }
        }

        [TestFixture]
        public class GetMembersTests
        {
            [Test]
            public void ShouldReturnStatusCode200WhenRequestSuccessful()
            {
                // arrange.
                var memberController = Create();

                // act.
                var result = memberController.GetMembers();

                // assert.
                Assert.That((result as OkObjectResult)?.StatusCode,
                    Is.EqualTo(200));
            }

            [Test]
            public void ShouldReturnStatusCode500WhenExceptionOccurs()
            {
                // arrange.
                var repository = new Mock<IMemberRepository>();
                repository.Setup(m => m.GetMembers())
                    .Throws(new IOException());
                var memberController = Create(repository: repository.Object);

                // act.
                var result = memberController.GetMembers();

                // assert.
                Assert.That((result as StatusCodeResult)?.StatusCode,
                    Is.EqualTo(500));
            }

            [Test]
            public void ShouldReturnMembersFromDataStore()
            {
                // arrange.
                var repository = new Mock<IMemberRepository>();
                var members = CreateMembers(2);
                repository.Setup(m => m.GetMembers())
                    .Returns(members);

                var mapper = new Mock<IMapper>();
                mapper.Setup(m => m.Map<List<MemberDto>>(members))
                    .Returns(ConvertMemberToDto(members).ToList());
                
                var memberController = Create(
                    repository: repository.Object,
                    mapper: mapper.Object);

                // act.
                var result = memberController.GetMembers();
                var firstMemberDto = ((result as OkObjectResult)?
                    .Value as IEnumerable<MemberDto>)?
                    .OrderBy(m => m.Id).FirstOrDefault();
                var firstMember = members.OrderBy(m => m.Id).FirstOrDefault();

                // assert.
                Assert.That(firstMemberDto?.FirstName, 
                    Is.EqualTo(firstMember?.FirstName));
            }

            [Test]
            [Explicit("WIP")]
            public void ShouldWriteToLogWhenExceptionOccurs()
            {
                // arrange.
                var repository = new Mock<IMemberRepository>();
                repository.Setup(m => m.GetMembers())
                    .Throws(new IOException());

                var log = new Mock<ILogger<MemberController>>();

                var memberController = Create(
                    repository: repository.Object,
                    logger: log.Object);

                // act.
                memberController.GetMembers();

                // assert.
                // fix: not too sure why this is not working,
                // -> moq docx is down :(
                log.Verify(
                    m => m.LogInformation(
                    It.IsAny<string>()),
                    Times.Once());
            }
        }

        private static MemberDto ConvertMemberToDto(Member member)
        {
            var memberDto = new MemberDto();

            memberDto.Id = member.Id;
            memberDto.FirstName = member.FirstName;
            memberDto.LastName = member.LastName;
            memberDto.DateOfBirth = member.DateOfBirth;
            memberDto.Email = member.Email;
            memberDto.Address = member.Address;
            memberDto.City = member.City;
            memberDto.Country = member.Country;
            memberDto.ZipCode = member.ZipCode;

            return memberDto;
        }
 private static IEnumerable<MemberDto> ConvertMemberToDto(IEnumerable<Member> members)
        {
            var memberDtos = new List<MemberDto>();
            foreach (var member in members)
            {
                var memberDto = new MemberDto();

                memberDto.Id = member.Id;
                memberDto.FirstName = member.FirstName;
                memberDto.LastName = member.LastName;
                memberDto.DateOfBirth = member.DateOfBirth;
                memberDto.Email = member.Email;
                memberDto.Address = member.Address;
                memberDto.City = member.City;
                memberDto.Country = member.Country;
                memberDto.ZipCode = member.ZipCode;

                memberDtos.Add(memberDto);
            }

            return memberDtos;
        }

        private static IEnumerable<Member> CreateMembers(int numberOfMembers)
        {
            var members = new List<Member>();

            for (var i = 1; i <= numberOfMembers; i++) 
            {
                var member = CreateMember(id: i);
                members.Add(member);
            }

            return members;
        }

        private static Member CreateMember(
            int? id = null,
            string? firstname = null,
            string? lastname = null,
            DateTime? dateOfBirth = null,
            string? email = null,
            string? address = null,
            string? city = null,
            string? country = null,
            string? zipCode = null)
        {
            var random = new Random();
            return new Member
            {
                Id = id ?? random.Next(),
                FirstName = firstname ?? random.Next().ToString(),
                LastName = lastname ?? random.Next().ToString(),
                DateOfBirth = dateOfBirth ?? DateTime.Now.AddYears(- new Random().Next(100)),
                Email = email ?? random.Next().ToString(),
                Address = address ?? random.Next().ToString(),
                City = city ?? random.Next().ToString(),
                Country = country ?? random.Next().ToString(),
                ZipCode = zipCode ?? random.Next().ToString(),
            };
        }

        private static MemberController Create(IMemberRepository? repository = null,
                                     IMapper? mapper = null,
                                     ILogger<MemberController>? logger = null)
        {
            repository = repository ?? new Mock<IMemberRepository>().Object;
            mapper = mapper ?? new Mock<IMapper>().Object;
            logger = logger ?? new Mock<ILogger<MemberController>>().Object;

            return new MemberController(repository, mapper, logger);
        }
    }
}
