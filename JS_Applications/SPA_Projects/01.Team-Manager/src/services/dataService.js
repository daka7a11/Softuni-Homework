import * as request from "./request.js";

const endpoints = {
  allTeams: "/data/teams",
  allMembers: "/data/members?where=status%3D%22member%22",
  createTeam: "/data/teams",
  memberRequest: "/data/members",
  editMember: "/data/members",
  teamById: "/data/teams",
  allMemberships: (teamId) =>
    `/data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`,
  editTeam: "/data/teams",
  deleteMember: "/data/members",
};

export async function getAllTeams() {
  return await request.get(endpoints.allTeams);
}

export async function getAllMembers() {
  return await request.get(endpoints.allMembers);
}

export async function createTeam(team) {
  return await request.post(endpoints.createTeam, team);
}

export async function memberRequest(teamId) {
  return await request.post(endpoints.memberRequest, { teamId });
}

export async function editMember(memberId, member) {
  return await request.put(endpoints.editMember + `/${memberId}`, member);
}

export async function getTeamById(teamId) {
  return await request.get(endpoints.teamById + `/${teamId}`);
}

export async function getTeamMembers(teamId) {
  return await request.get(endpoints.allMemberships(teamId));
}

export async function editTeam(teamId, team) {
  return await request.put(endpoints.editTeam + `/${teamId}`, team);
}

export async function deleteMember(memberId) {
  return await request.delete(endpoints.deleteMember + `/${memberId}`);
}
