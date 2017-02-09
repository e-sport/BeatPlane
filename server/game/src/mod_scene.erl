-module(mod_scene).

-include("game_pb.hrl").
-include("game.hrl").

-export([enter/3]).

enter(#m__scene__enter__c2s{}, Reader, Role) ->
    Name = Role#role.name,
    Roles = ets:tab2list(roles_online),
    RolesS2C = #m__scene__roles__s2c{
        roles = [#p_role{name = binary_to_list(N), x = 0, y = 0} || #role{name = N} <- Roles, N =/= Name]},
    Reader ! {send, RolesS2C},
    Role.
