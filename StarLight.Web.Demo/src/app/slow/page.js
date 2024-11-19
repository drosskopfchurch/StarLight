"use client";
import React from 'react';
import { Typography } from '@mui/material';
import useSWR from 'swr'
import DemoGraph from '@/components/smart/demo-graph';
import LoadingPage from '@/components/dumb/loading';

const fetcher = (url) => fetch(url).then((res) => res.json());

const LineChartComponent = () => {
  const { data, error, isLoading } = useSWR('/api/pricesslow', fetcher)

  if (isLoading) return <LoadingPage>Loading Slow Example</LoadingPage>
  if (error) return <div>Error: {error}</div>

  return (
    <>
      <Typography variant='h2' component="h1" gutterBottom>
        Slow Example</Typography>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default LineChartComponent;