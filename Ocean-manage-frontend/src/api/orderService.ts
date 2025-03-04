//订单服务 API（示例）
import { grpcRequest } from './grpcClient';

// 订单请求 & 响应接口
export interface OrderRequest {
  orderId: string;
}
export interface OrderResponse {
  orderId: string;
  status: string;
}

/**
 * 获取订单信息
 * @param {string} orderId 订单号
 * @returns {Promise<OrderResponse>} 订单数据
 */
export const getOrder = async (orderId: string): Promise<OrderResponse> => {
  return await grpcRequest('order', 'GetOrder', { orderId });
};
