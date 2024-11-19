"use client";
import LoadingPage from '@/components/dumb/loading';
import DemoGraph from '@/components/smart/demo-graph';
import React from 'react';
import useSWR from 'swr'

const fetcher = (url) => fetch(url).then((res) => res.json());


const LineChartComponent = () => {
  const { data, error, isLoading } = useSWR('/api/prices', fetcher)


  if (isLoading) return <LoadingPage></LoadingPage>
  if (error) return <div>Error: {error}</div>

  return (
    <>
      <h1>Regular</h1>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default LineChartComponent;