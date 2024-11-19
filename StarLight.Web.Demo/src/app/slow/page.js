"use client";
import React, { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import { Autocomplete, TextField } from '@mui/material';
import useSWR from 'swr'
import DemoGraph from '@/components/smart/demo-graph';
import LoadingPage from '@/components/dumb/loading';

const fetcher = (url) => fetch(url).then((res) => res.json());

const mergeData = (data) => {
  const merged = {};
  data.forEach(item => {
    const date = new Date(item.date).toLocaleDateString();
    if (!merged[date]) {
      merged[date] = { date };
    }
    merged[date][item.securityId] = item.close;
  });
  return Object.values(merged);
};

const LineChartComponent = () => {
  const { data, error, isLoading } = useSWR('/api/pricesslow', fetcher)

  if (isLoading) return <LoadingPage></LoadingPage>
  if (error) return <div>Error: {error}</div>

  return (
    <>
      <h1>Slow</h1>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default LineChartComponent;