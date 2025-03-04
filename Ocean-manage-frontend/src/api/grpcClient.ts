//封装 gRPC HTTP 请求（通用）
import axios from 'axios';

/**
 * 通用 gRPC HTTP 客户端封装
 * @param {string} serviceName 服务名称（如：user、order）
 * @param {string} methodName 方法名称（如：GetUser）
 * @param {any} requestData 请求数据
 * @returns {Promise<any>} 返回后端响应数据
 */
export const grpcRequest = async (serviceName: string, methodName: string, requestData: any): Promise<any> => {
  try {
    const API_BASE_URL = `http://localhost:5182/api/${serviceName}/`;
    const response = await axios.post(`${API_BASE_URL}${methodName}`, requestData);
    return response.data;
  } catch (error) {
    console.error(`gRPC 请求失败: ${serviceName}.${methodName}`, error);
    throw error;
  }
};
