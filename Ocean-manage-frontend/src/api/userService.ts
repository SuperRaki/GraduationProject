//用户服务 API
import { grpcRequest } from './grpcClient';

// 用户请求 & 响应接口
export interface UserRequest {
  id: number;
}
export interface UserResponse {
  id: number;
  name: string;
  email: string;
}

/**
 * 获取用户信息
 * @param {number} userId 用户ID
 * @returns {Promise<UserResponse>} 用户数据
 */
export const getUser = async (userId: number): Promise<UserResponse> => {
  return await grpcRequest('user', 'GetUser', { id: userId});
};
