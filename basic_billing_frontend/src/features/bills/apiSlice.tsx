import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { NewBill } from "../../models/NewBill";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "http://localhost:5000/billing",
  }),
  endpoints: (builder) => ({
    getAllClients: builder.query({
      query: () => "/clients",
    }),
    getPendignBillsByClientId: builder.query({
      query: (id: string) => `/pending?ClientId=${id}`,
    }),
    postCreateBill: builder.mutation({
      query: (bill: NewBill) => ({
        url: "/bills",
        method: "POST",
        body: bill,
      }),
    }),
    postPayBill: builder.mutation({
      query: (pendingBill) => ({
        url: "/pay",
        method: "POST",
        body: pendingBill,
      }),
    }),
    getPaymentHistoryByCategory: builder.query({
      query: (id: string) => `/search?category=${id}`,
    }),
  }),
});

export const {
  useGetAllClientsQuery,
  useGetPendignBillsByClientIdQuery,
  usePostCreateBillMutation,
  usePostPayBillMutation,
  useGetPaymentHistoryByCategoryQuery
} = apiSlice;
